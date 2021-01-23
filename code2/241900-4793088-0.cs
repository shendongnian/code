     StringBuilder SbCSV = new StringBuilder();
                int ActualSent;
                int CommitmentSent;
                webservice.summaryResults returned = convert(out ActualSent, out CommitmentSent);
                //txtResult.Text = System.Convert.ToString(returned.status);
                SbCSV.Append(System.Convert.ToString(returned.status));
                //txtMoreRes1.Text = returned.errorDetails[0].errorDetails;
                SbCSV.Append("," + returned.errorDetails[0].errorDetails);
                //txtMoreRes2.Text = returned.errorDetails[1].errorDetails;
                SbCSV.Append("," + returned.errorDetails[1].errorDetails);
                // Similary ...
                txtMoreRes3.Text = returned.errorDetails[2].errorDetails;
                txtMoreRes4.Text = returned.errorDetails[3].errorDetails;
                actualSum.Text = System.Convert.ToString(returned.actualSum);
                commitmentSum.Text = System.Convert.ToString(returned.commitmentSum);
                date.Text = System.Convert.ToString(DateTime.Today);
                time.Text = System.Convert.ToString(DateTime.Now.TimeOfDay);
                actualsumsent.Text = ActualSent.ToString();
                commitmentsumsent.Text = CommitmentSent.ToString();
                errorposition1.Text = System.Convert.ToString(returned.errorDetails[0].errorPosition);
                errorposition2.Text = System.Convert.ToString(returned.errorDetails[1].errorPosition);
                errorposition3.Text = System.Convert.ToString(returned.errorDetails[2].errorPosition);
                errorposition4.Text = System.Convert.ToString(returned.errorDetails[3].errorPosition);
    
                TextWriter Tw = new StreamWriter("Your_FilePath_Name.csv");
                Tw.Write(SbCSV.ToString());
                Tw.Close();
                Tw.Dispose();
