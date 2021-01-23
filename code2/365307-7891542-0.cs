    void PopulateTextBoxes()
    {
        string format = "MLB028A-MTRSPR-B-{1}";
        string format2 = "SPACER, {0}, CFG-{1} MLB028";
        string fileName = @"C:\Engineering\Engineering\SW Automation\Linear Actuator Technology\MLC Series\Models\MLB028Z-MTRSPR-B-{1}.SLDPRT";
        for(string start = "A"; start != "Z"; start = GetNextBase26(start))
        {
            if(File.Exists(String.Format(fileName,start)))
            {
                textBox3.Text = String.Format(format,start);
                textBox5.Text = String.Format(format2,textBox3.Text,start);
                break;
            }
        }
    }
    // CODE FROM http://stackoverflow.com/questions/1011732/iterating-through-the-alphabet-c-sharp-a-caz
    private static string GetNextBase26(string a)
    {
        return Base26Sequence().SkipWhile(x => x != a).Skip(1).First();
    }
    private static IEnumerable<string> Base26Sequence()
    {
        long i = 0L;
        while (true)
            yield return Base26Encode(i++);
    }
    private static char[] base26Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    private static string Base26Encode(Int64 value)
    {
        string returnValue = null;
        do
        {
            returnValue = base26Chars[value % 26] + returnValue;
            value /= 26;
        } while (value-- != 0);
        return returnValue;
    }
