    public class UserIdParameter : Parameter
    {
        protected override object Evaluate(HttpContext context, 
            System.Web.UI.Control control)
        {
            var name = GetName();
            return UsefulStaticMethods.GetUserNameFromUserGuid(name);
        }
    }
    <SelectParameters>
            <custom:UserIdParameter Name="UserID" />
    </SelectParameters> 
