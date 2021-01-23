    > public static string netsh(String IPv6)
    >     {
    >       Process p = new Process();
    >       p.StartInfo.FileName = "netsh.exe";
    >       String command = "int ipv6 show neigh"; 
    >       Console.WriteLine(command);
    >       p.StartInfo.Arguments = command;
    >       p.StartInfo.UseShellExecute = false;
    >       p.StartInfo.RedirectStandardOutput = true;
    >       p.Start();
    > 
    >       String output = "go";
    >       while (output!=null){
    >         try
    >         {
    >           output = p.StandardOutput.ReadLine();
    >         }
    >         catch (Exception)
    >         {
    >           output = null;
    >         }
    >         if (output.Contains(IPv6))
    >         {
    >           // Nimmt die Zeile in der sich die IPv6 Addresse und die MAC Addresse des Clients befindet
    >           // Löscht den IPv6 Eintrag, entfernt alle Leerzeichen und kürzt den String auf 17 Zeichen, So erschein die MacAddresse im Format "33-33-ff-0d-57-00"
    > 
    >           output = output.Replace(IPv6, "").Replace(" ", "").TrimToMaxLength(17) ;
    >           return output;
    >         }
    >       }
    >       return null;
    > 
    >    }
