    using WatiN.Core;
    ...
    foreach (IE ie in IE.InternetExplorers())
    {
       Console.Out.WriteLine(ie.Html);
    }
