 c#
using System.Text.Json
// ...
string json = "{ \"boolvalue\": true }";
JsonDocument doc = JsonDocument.Parse(json);
JsonElement elem = doc.RootElement.GetProperty("boolvalue");
if (elem.ValueKind == JsonValueKind.True || elem.ValueKind == JsonValueKind.False)
{
    // elem is boolean
    bool result = elem.GetBoolean();
}
