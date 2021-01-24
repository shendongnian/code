namespace Attribute
{
   [AttributeUsage(Inherited =true)]
   class RequiredPropertyAttribute : Attribute //There is a problem.
   {
   }
   [AttributeUsage(AttributeTargets.Class,AllowMultiple = true)]
   class ToTableAttribute : Attribute //There is also a problem.
   {
       string _tableName;
       public ToTableAttribute(string tableName)
       {
           _tableName = tableName;
       }
   }
}
And if not like that, and the classes are not part of a namespace then there is a namespace else where, either in your project or a referenced dll, whose name is `Attribute`. Basically, the reason the above isn't working is because IntelliSense is assuming that your classes are inheriting from the namespace named `Attribute` rather then the class `System.Attribute`. So to fix this all you would need to do is either change the namespace's name or prepend to the `Attribute`s, after the colons, `System.` so your fixed code would be like this:
namespace Attribute //This should be renamed instead or else for every attribute class you create you will need to specify "System.Attribute" as the base
{
   [AttributeUsage(Inherited =true)]
   class RequiredPropertyAttribute : System.Attribute //Will tell IntelliSense that your class is inheriting from the Attribute class rather than the above namespace
   {
   }
   [AttributeUsage(AttributeTargets.Class,AllowMultiple = true)]
   class ToTableAttribute : System.Attribute
   {
       string _tableName;
       public ToTableAttribute(string tableName)
       {
           _tableName = tableName;
       }
   }
}
