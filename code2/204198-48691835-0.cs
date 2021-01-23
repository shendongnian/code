    using BCL.easyPDF.Printer;
    
    namespace TestPrinter
    {
       class Program
       {
          static void Main(string[] args)
          {
             if(args.Length != 2)
                return;
    
             string inputFileName = args[0];
             string outputFileName = args[1];
             Printer printer = new Printer();
             try
             {
                IEPrintJob printjob = printer.IEPrintJob;
                printjob.PrintOut(inputFileName, outputFileName);
             }
             catch(PrinterException ex)
             {
                System.Console.WriteLine(ex.Message);
             }
             finally
             {
                printer.Dispose();
             }
          }
       }
    }
