    string a = "Project.Repositories.Methods";
    string b = "Project.Repositories.DataSets.Project.Repositories.Entity";
    int i;
    for (i = 0; i < a.Length; i++)
        if (a[i] != b[i])
            break;
    Console.WriteLine(b.Substring(i));
