            const string TestData =
                " <input > [ <input type=\"hidden\" value=\"263\" />First Name] [kdkgh[ <br /> <input 567> ag [<input type=\"hidden\" value=\"264\" />Last Name] dg input value=\"345\" ";
            var r = new Regex(@"\[\s*<input type=""hidden"" value=""([^\]]+)"" />([^\]]+)\]");
            var matches = r.Matches(TestData);
            Console.WriteLine("{0}, {1}", matches[0].Groups[1].Value, matches[0].Groups[2].Value);
            Console.WriteLine("{0}, {1}", matches[1].Groups[1].Value, matches[1].Groups[2].Value);
