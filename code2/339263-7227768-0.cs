    XElement main = XElement.Parse(
    @"<Users>
        <User>
            <Name>John Smith</Name>
            <test>
                <Date>23.05.2011</Date>
                <points>33</points>
            </test>
            <test>
                <Date>22.06.2011</Date>
                <points>29</points>
            </test>
        </User>
    </Users>");
    var users =
       from m in main.Elements("User")
       where (string) m.Element("Name") == "John Smith"
       select m.Element("Date");
    foreach(var user in users)
       Console.WriteLine(user.Value);
