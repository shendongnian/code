    string a = "Project.Repositories.Data";
    string b = "Project.Repositories.DataSets.Project.Repositories.Entity";
    int dotIdx = 0;
    for (int i = 0; i < a.Length; i++)
        if (a[i] != b[i])
            break;
        else
            dotIdx = a[i] == '.' ? (i+1) : dotIdx;
    Console.WriteLine(b.Substring(dotIdx));
