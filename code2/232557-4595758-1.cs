    try
    {
        System.IO.Directory.Move(@"c:\d1\d2\d3\", @"c:\d1\new\");
    }
    catch (System.UnauthorizedAccessException)
    {
        MessageBox.Show("You do not have access to move this files/directories");
    }
    catch(System.IO.DirectoryNotFoundException)
    {
        MessageBox.Show("The directory to move files/directories from was not found")
    }
    catch
    {
        MessageBox.Show("Something blew up!");
    }
