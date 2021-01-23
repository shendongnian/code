    using System.Linq;
    // for each param, encode it as 'xyz', where xyz is properly escaped
    // e.g. if the source was foo'bar then xyz is foo\x27bar for a final
    // result of 'foo\x27bar' in the output. This is a valid JS literal
    // which evaluates to the string foo'bar
    var params = (new string[] { service_id, psn, dtmonth, ..., service })
       .Select(p => "'" + JsEncoder.EncodeString(p) + "'");
    // Then join all the 'xyz' with commas so result is 'a','b',...'c'
    var strScriptParam = string.join(",", params.ToArray());
    // note no "javascript:" protocol for onclick
    e.Row.Attributes.Add("onclick", "return ShowGridRow(" + strScriptParam + ");");
