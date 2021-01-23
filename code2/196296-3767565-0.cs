           public class A
           {
               [Include]
               [Association("Relation1","ComplexPropertyId","Id")]
               public virtual ComplexProperty property {get;set;}
               public virtual int ? ComplexPropertyId {get;set;}
           }
