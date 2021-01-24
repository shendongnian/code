c#
using System;
class ParseTest
{
    static string GetCorrelationId(string message)
    {
        int i = message.IndexOf(": ") + 2; //length of ": "
        int j = message.IndexOf("Request");
        return message.Substring(i, j-i).Trim();
    }
    static string GetRFAPI(string message)
    {
        int i = message.IndexOf("API: ") + 5; //length of "API: "
        int j = message.IndexOf("Caller");
        return message.Substring(i, j-i).Trim();
    }
    static string GetCaller(string message)
    {
        int i = message.IndexOf("Caller:") + 7; //length of "Caller: "
        int j = message.IndexOf(" CorrelationId");
        return message.Substring(i, j-i).Trim();
    }
    static string GetRqSchema(string message)
    {
        int i = message.IndexOf("RequestedSchemas:") + 17; //length of "RequestedSchemas:"
        int j = message.IndexOf(",  TenantId:");
        return message.Substring(i, j-i).Trim();
    }
    static string GetTenantId(string message)
    {
        int i = message.IndexOf("TenantId:") + 9; //length of "TenantId: "
        return message.Substring(i).Trim();
    }
    static void Main()
    {
        string m = @"CorrelationId: b99fb632-78cf-4910-ab23-4f69833ed2d9
                    Request for API: /api/acmsxdsreader/readpolicyfrompolicyassignment Caller:C2F023C52E2148C9C1D040FBFAC113D463A368B1 CorrelationId: b99fb632-78cf-4910-ab23-4f69833ed2d9 RequestedSchemas: {urn:schema:Microsoft.Rtc.Management.Policy.Voice.2008}VoicePolicy, {urn:schema:Microsoft.Rtc.Management.Policy.Voice.2008}OnlineVoiceRoutingPolicy,  TenantId: 7a205197-8e59-487d-b9fa-3fc1b108f1e5";
        Console.WriteLine(GetCorrelationId(m));
        Console.WriteLine(GetRFAPI(m));
        Console.WriteLine(GetCaller(m));
        Console.WriteLine(GetRqSchema(m));
        Console.WriteLine(GetTenantId(m));
    }
}
You can run it [here][1].
If, on the other hand, you want to write a parser (*this is kind of lazy one* ), then that's another matter for your researching pleasure.
[1]: https://repl.it/repls/WelllitSlightGigabyte
