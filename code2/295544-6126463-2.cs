    try {
      ...
    } catch (DirectoryNotFoundException dnfex) { // class DirectoryNotFoundException : IOException
      Console.WriteLine("{0} Directory Not Found", dnfex);
    } catch (IOException ioex) { // class IOException : SystemException
      Console.WriteLine("{0} System IO Exception", ioex);
    } catch (SystemException sex) { // class SystemException : Exception
      Console.WriteLine("{0} System Exception", sex);
    } catch (Exception ex) {
      Console.WriteLine("{0} Generic Exception", ex);
    }
