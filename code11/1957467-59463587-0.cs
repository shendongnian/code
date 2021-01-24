[{
        "name": "apple.com",
        "status": "regthroughothers",
        "classkey": "domcno"
    },
    {
        "name": "asdfgqwx.com",
        "status": "available",
        "classkey": "domcno"
    },
    {
        "name": "microsoft.org",
        "status": "unknown",
        "classkey": ""
    },
    {
        "name": "apple.org",
        "status": "unknown",
        "classkey": ""
    },
    {
        "name": "microsoft.com",
        "status": "regthroughothers",
        "classkey": "domcno"
    },
    {
        "name": "asdfgqwx.org",
        "status": "unknown",
        "classkey": "domcno"
    }]
Step 2: Put your pointer into the position you want to write that.
Select `Edit` >> `Paste Special` >> `Paste JSON as Classes`
>Result:
    public class Rootobject
    {
        public Class1[] Property1 { get; set; }
    }
    public class Class1
    {
        public string name { get; set; }
        public string status { get; set; }
        public string classkey { get; set; }
    }
Step3: You can change something with the result you want. Then, Using `JsonConvert.DeserializeObject<Foo>(yourString)` to do the work.
