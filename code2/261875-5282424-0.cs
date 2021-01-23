       public class CustomRequiredAttribute : RequiredAttribute{
           public CustomRequiredAttribute():base(){
               ErrorMessageResourceType = typeof(Resources);
               ErrorMessageResourceName = "RequiredAttribute_ValidationError");
           }
       }
