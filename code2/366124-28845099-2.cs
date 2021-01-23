                    Utils.Logger.Info("", "AsystScanner/dynamicDotNetTwain2_OnPostAllTransfers");
                    Utils.Logger.Info("Closing down application!", "AsystScanner/dynamicDotNetTwain2_OnPostAllTransfers");
    
                    // caller should close down app, added 3/3/15
                    dynamicDotNetTwain2.CloseSource();
                    dynamicDotNetTwain2.CloseSourceManager();
    
                    System.Windows.Forms.Application.Exit();
    no no!  don't do a close here.
                    //try
                    //{
                    //    Close();
                    //}
                    //catch (Exception ex)
                    //{
                    //    MessageBox.Show(ex.Message + "  Routine=dynamicDotNetTwain2_OnPostAllTransfers/Close() statement failed. [EJS1503031630]");
                    //}
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "  Routine=dynamicDotNetTwain2_OnPostAllTransfers [EJS1503031631]");
                }
