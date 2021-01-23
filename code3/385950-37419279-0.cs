    public string CleanThumbprint(string mmcThumbprint)
        {
            //replace spaces, non word chars and convert to uppercase
            return Regex.Replace(mmcThumbprint, @"\s|\W", "").ToUpper();
        }
    ...
            var myThumbprint = CleanThumbprint("‎b3 ab 84 e5 1e e5 e4 75 e7 a5 3e 27 8c 87 9d 2f 05 02 27 56");
            var myCertificate = certificates.Find(X509FindType.FindByThumbprint, myThumbprint, true)[0];
