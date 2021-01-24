public TestBean(string name, string suppose, string fact, object msg = null)
{
    this.name = name;
    this.suppose = suppose;
    this.fact = fact;
    pass = suppose == fact;
    if (SHOW_MSG)
        this.msg = msg;
    else
        this.msg = null;
}
Use the bean like this in controller:
[HttpGet]
public string TestAll(){
    JObject obj = (JObject)JsonConvert.DeserializeObject(TestMethod());
    TestBean beans = new TestBean[]{
        new TestBean('TestMethod',true+"",obj+"",obj)
    };
    return JsonConvert.SerializeObject(beans);
}
When I visit the url localhost:.../TestAll, I will get json
[
    {
        "pass":true,
        "name":"TestMethod",
        "suppose":"True",
        "fact":"True",
        "msg":"True"
    }
]
Honestly, it's not easy to use, especially when the test case change frequently.
