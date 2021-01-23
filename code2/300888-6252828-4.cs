    //A little prep
    const int IterationThrottleMS = 1000;
    const int MaxRetries = 5;
    public static void Retry(Action fileAction)
    {
        Retry(fileAction, 1)
    }
    ...
    // Your first example
    
    try
    {
        Retry(() => {
            using (FileStream Fs = new FileStream(
                    fileName, 
                    FileMode.Open, 
                    FileAccess.Write)
                StreamReader stream = new StreamReader(Fs);
        });
    }
    catch (FileNotFoundException) {/*Somthing Sensible*/} 
    catch (ArgumentException) {/*Somthing Sensible*/}
    catch (IOException) {/*Somthing Sensible*/}
    ...
    // Your second example
    try
    {
        Retry(() => writePermission.Demand());
    }
    catch (FileNotFoundException) {/*Somthing Sensible*/} 
    catch (ArgumentException) {/*Somthing Sensible*/}
    catch (IOException) {/*Somthing Sensible*/} 
