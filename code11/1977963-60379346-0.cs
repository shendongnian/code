        if (str.Contains(".")){
            isValid = false;
        }
        if (str.Contains("7")){
            isValid = false;
        }
        if (isValid){
            Console.WriteLine("Success");
        }
        return isValid;
    }
