cs
public string UserLevelsHidden
{
    get => UserLevels.SerializeForHidden();
    set => UserLevels = value.DeserializeForHidden(UserLevels);
}
Now the values of `UserLevels` are saved in the form and re-created at the post with:
html
<input type="hidden" asp-for="UserLevelsHidden"/>
This will work for any serializable type, not just for Lists.
Extension methods:
cs
using Newtonsoft.Json;
using System.Web;
namespace Forestbrook.Web
{
    public static class WebHelper
    {
        /// <summary>
        /// Deserialize a value from a hidden HTML Form field which was serialized
        /// with SerializeForHidden to its original type.
        /// </summary>
        /// <typeparam name="T">Type to deserialize to</typeparam>
        /// <param name="value">serialized and HtmlEncoded string from HTML form</param>
        /// <param name="_">Target property only used to simplify detection of T. May be null.</param>
        /// <returns>Deserialized object or null when value was null or empty</returns>
        public static T DeserializeForHidden<T>(this string value, T _)
        {
            if (string.IsNullOrEmpty(value))
                return default;
            return JsonConvert.DeserializeObject<T>(HttpUtility.HtmlDecode(value));
        }
        /// <summary>
        /// Serialize a complex value (like a List) to be stored in a hidden HTML Form field
        /// </summary>
        /// <param name="value">Value to serialize</param>
        /// <returns>Json serialized and HtmlEncoded string</returns>
        public static string SerializeForHidden(this object value)
        {
            if (value == null)
                return null;
            return HttpUtility.HtmlEncode(JsonConvert.SerializeObject(value,
                new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore }));
        }
    }
}
Mind that the `T _` parameter in DeserializeForHidden is only added to make the use of DeserializeForHidden easier. You can remove it if you like, but then you always have to specify the type.
