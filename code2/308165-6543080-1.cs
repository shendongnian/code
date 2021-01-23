        // Execute the method from the requested .dll using reflection (System.Reflection).
        Assembly DLL = Assembly.LoadFrom(strDllPath);
        Type classType = DLL.GetType(String.Format("{0}.{0}", strNsCn));
        object classInst = Activator.CreateInstance(classType, paramObj);
        Form dllWinForm = (Form)classInst;	
        dllWinForm.ShowDialog();
