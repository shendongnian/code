    public class FromExpando : KnownSourceValueInjection<ExpandoObject>
    {
        protected override void Inject(ExpandoObject source, object target)
        {
            var d = source as IDictionary<string, object>;
            if (d == null) return;
            var tprops = target.GetProps();
            foreach (var o in d)
            {
                var tp = tprops.GetByName(o.Key);
                if (tp == null) continue;
                var newValue = Convert.ChangeType(o.Value, tp.PropertyType); 
                
                tp.SetValue(target, newValue);
            }
        }
    }
