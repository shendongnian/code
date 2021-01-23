       object oMissing = System.Reflection.Missing.Value;
       ((Microsoft.Office.Interop.Word._Application)wordApp).Quit(ref oMissing, ref oMissing, ref oMissing);
                   wordApp = null;
                   GC.Collect();
                   GC.WaitForPendingFinalizers();
