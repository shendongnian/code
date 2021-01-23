         Process p = null;
         if (p == null)
          {
            p = new Process();
            p.StartInfo.FileName = "Calc.exe";
            p.Start();
          }
         else
             {
                p.Close();
                p.Dispose();
             }
         }
        catch (Exception e)
            {
                MessageBox.Show("Excepton" + e.Message);
            }
