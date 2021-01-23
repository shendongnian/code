    string pwd = "ebskey";
    string DR = Request.QueryString["DR"];
    DR = DR.Replace(' ', '+');
    string sQS = Base64Decode(DR);
    DR = EBSHelper.Decrypt(pwd, sQS, false);
    var list = Regex.Matches(DR, @"(?<key>\w+)=(?<value>\w+)(&|$)")
        .Cast<Match>()
        .Select(arg => new { Key = arg.Groups["key"].Value, Value = arg.Groups["value"].Value })
        .ToList();
    GridView1.DataSource = list;
    GridView1.DataBind();
