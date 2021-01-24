    // create an array of all your random digits and characters
    // ... if you want to prefer any, just add them multiple times
    char[] alphanum = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    for (int i = 0; i < WindowForm.GalaxySize; i++)
    {
        // define an array to contain the parts of your random name
        string[] nameparts = new string[6];
        // loop as many times as necessary to fill your nameparts array
        for (int j = 0; j < nameparts.Length; j++)
        {
            // pick a random character from your alphanum array
            int c = rnd.Next(0, alphanum.Length - 1);
            // ... and store it in the nameparts array
            nameparts[j] = alphanum[c].ToString();
        }
        // combine the name parts in the desired format
        string CGenSystem = string.Format("{0}{1}-{2}{3}-{4}{5}", nameparts);
    }
