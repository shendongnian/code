                Utils.Logger.Info("", "AsystScanner/dynamicDotNetTwain2_OnPostAllTransfers");
                Utils.Logger.Info("Closing down application!", "AsystScanner/dynamicDotNetTwain2_OnPostAllTransfers");
                // caller should close down app, added 3/3/15
                dynamicDotNetTwain2.CloseSource();
                dynamicDotNetTwain2.CloseSourceManager();
                System.Windows.Forms.Application.Exit();
