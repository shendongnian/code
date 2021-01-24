    public class TestModel
        {
            [EmailsCustom(@"[a-z0-9!#$%&' * +/=?^ _`{|}~-]+(?:\.[a-z0- 
        9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0- 
        9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "{0} is invalid email")]
            public List<string> Emails { get; set; }
        }
