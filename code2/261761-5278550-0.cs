     public class SqlRecord<T>{
         where T: ISqlDataObject
         public TAssociationRecord GetOneToOneAssociation<TAssociationRecord>(Expression<Func<T,TAssociationRecord>>> getAssociationPropertyExpression)
              where TAssociationRecord : ISqlDataObject
         {
         } 
         
         public IEnumerable<TAssociationRecord> GetOneToManyAssociation(Expression<Func<T,EntitySet<TAssociationRecord>>> getAssociationPropertyExpression)
             where TAssociationRecord: ISqlDataObject
         {
         }
     }
