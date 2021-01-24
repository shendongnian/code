[AuditIgnore]
public class MySpecialClass
{
  public Unit? UnitOfMeasure { get; set; }
  public float? Value { get; set; }
}
Audit.Core.Configuration.Setup()
                .UseEntityFramework(
                ef => ef
                    .AuditTypeExplicitMapper(m => m
                    .Map<FirstClass, FirstClassAudit>((frst, auditFrst) =>
                    {
                        MapMatchedProperties(frst, auditFrst);
                        //Map the tag fields in here
                        auditFrst.Tag = frst.Installation.Tag;
                        //Some more props here
                    })
                    .Map<SecondClass, SecondClassAudit>((scnd, auditScnd)=>
                    {
                        MapMatchedProperties(scnd, auditScnd);
                    })
                    .AuditEntityAction((ev, ent, auditEntity) =>
                    {
                        ((AuditClass)auditEntity).AuditMessage = ent.Action;
                    }))
                    .IgnoreMatchedProperties()
                );
Also I added my own mapping function "MapMatchedProperties" to correctly map every single field with special exceptions for "MySpecialClass"
private static void MapMatchedProperties(object source, object destination)
        {
            var sourceType = source.GetType();
            var destinationType = destination.GetType();
            var sourceFields = sourceType.GetProperties();
            var destinationFields = destinationType.GetProperties();
            foreach (var field in sourceFields)
            {
                var destinationField = destinationFields.FirstOrDefault(f => f.Name.Equals(field.Name));
                if (destinationField != null && (destinationField.PropertyType == field.PropertyType))
                {
                    //Normal field
                    var sourceValue = field.GetValue(source);
                    destinationField.SetValue(destination, sourceValue);
                } else if(destinationField != null && (destinationField.PropertyType == typeof(AuditMySpecialClass) && field.PropertyType== typeof(MySpecialClass)))
                {
                    //MySpecialClass field
                    var destinationMeasure = new AuditMySpecialClass();
                    var sourceValue = (MySpecialClass)field.GetValue(source);
                    if (sourceValue != null || sourceValue.IsEmpty())
                    {
                        destinationMeasure.UnitOfMeasure = sourceValue.UnitOfMeasure;
                        destinationMeasure.Value = sourceValue.Value;
                    }
                    destinationField.SetValue(destination, destinationMeasure);
                }
            }
        }
