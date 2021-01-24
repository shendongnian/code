{--- IIS ---}
const
  IISServerName = 'localhost';
  IISServerNumber = '1';
  IISURL = 'http://127.0.0.1';
  IISApplicationPoolName = 'Test Pool';
  ERROR_NOT_FOUND = 1168;
  ERROR_NOT_SUPPORTED = 50;
  MD_APPPOOL_IDENTITY_TYPE_LOCALSYSTEM = 0;
  MD_APPPOOL_IDENTITY_TYPE_LOCALSERVICE = 1;
  MD_APPPOOL_IDENTITY_TYPE_NETWORKSERVICE = 2;
  MD_APPPOOL_IDENTITY_TYPE_SPECIFICUSER = 3;
  MD_LOGON_INTERACTIVE = 0;
  MD_LOGON_BATCH = 1;
  MD_LOGON_NETWORK = 2;
  MD_LOGON_NETWORK_CLEARTEXT = 3;
 procedure IISButtonOnClick(Sender: TObject);
 var
  IIS, webService, webServer, webRoot, vDir, vDirApp :Variant;
  appPools, appPool :Variant;
  webSiteId :String;
  ErrorCode: Integer;
begin
    if MsgBox('Setup will now connect to Microsoft IIS Server ''' + IISServerName + ''' and create a virtual directory. Do you want to continue?', mbInformation, mb_YesNo) = idNo then
    Exit;
  { Create the main IIS COM Automation object. }
  try
    IIS := CreateOleObject('IISNamespace');
  except
    RaiseException('Please install Microsoft IIS first.'#13#13'(Error ''' + GetExceptionMessage + ''' occurred)');
  end;
  { Get application pools. }
  appPools := IIS.GetObject('IIsApplicationPools', 'localhost/W3SVC/AppPools');
  try
    { Check if the application pool already exists. }
    appPool := appPools.GetObject('IIsApplicationPool', IISApplicationPoolName);
  except
   //  Create the application pool. }
    try
      appPool := appPools.Create('IIsApplicationPool', IISApplicationPoolName);
      appPool.LogonMethod := MD_LOGON_NETWORK_CLEARTEXT;
      appPool.AppPoolIdentityType := MD_APPPOOL_IDENTITY_TYPE_NETWORKSERVICE;
      appPool.SetInfo();
    except
     Log('Failed to create an apllication pool.');
      Exit;
    end;
  end;
  { Connect to the IIS server. }
  webService := IIS.GetObject('IIsWebService', IISServerName + '/w3svc');
  { Get the website. }
  webServer := webService.GetObject('IIsWebServer', IISServerNumber);
  webRoot := webServer.GetObject('IIsWebVirtualDir', 'Root');
  { Delete the virtual dir if it already exists. }
  try
    webRoot.Delete('IIsWebVirtualDir', 'testing');
    webRoot.SetInfo();
  except
    { An exception will be raised if there is not such a website. }
  end;
  { Create the virtual directory. }
  try
    vDir := webRoot.Create('IIsWebVirtualDir', 'testing');
    vDir.AccessRead := True;
    vDir.AccessScript := True;
    vDir.AppFriendlyName := 'Test friendly name';
    VDir.Path := 'C:\inetpub\testing';
    vDir.AppCreate(True);
    vDir.SetInfo();
      MsgBox('Created virtual directory ''' + VDir.Path + '''.', mbInformation, mb_Ok);
      
  { Write some html and display it }
  if MsgBox('Setup will now write some HTML and display the virtual directory. Do you want to continue?', mbInformation, mb_YesNo) = idNo then
    Exit;
  ForceDirectories(VDir.Path);
  SaveStringToFile(VDir.Path + '/indexFile.htm', '<html><body>Finally it worked .............!</body></html>', False);
  if not ShellExecAsOriginalUser('open', IISURL + '/testing/indexFile.htm', '', '', SW_SHOWNORMAL, ewNoWait, ErrorCode) then
    MsgBox('Can''t display the created virtual directory: ''' + SysErrorMessage(ErrorCode) + '''.', mbError, mb_Ok);
  except
    Log('Failed to create a virtual directory.');
    Exit;
  end;
  { Assign the application pool to the virtual directory. }
  try
    vDir := webRoot.GetObject('IIsWebVirtualDir', 'testing');
    vDir.AppPoolId := IISApplicationPoolName;
    vDir.SetInfo();
  except
   Log('Failed to assign the application pool to the virtual directory.');
    Exit;
  end;
end;
{---}
procedure CreateButton(ALeft, ATop: Integer; ACaption: String; ANotifyEvent: TNotifyEvent);
begin
  with TButton.Create(WizardForm) do begin
    Left := ALeft;
    Top := ATop;
    Width := WizardForm.CancelButton.Width;
    Height := WizardForm.CancelButton.Height;
    Caption := ACaption;
    OnClick := ANotifyEvent;
    Parent := WizardForm.WelcomePage;
  end;
end;
procedure InitializeWizard();
var
  Left, LeftInc, Top, TopInc: Integer;
begin
  Left := WizardForm.WelcomeLabel2.Left;
  LeftInc := WizardForm.CancelButton.Width + ScaleX(8);
  TopInc := WizardForm.CancelButton.Height + ScaleY(8);
  Top := WizardForm.WelcomeLabel2.Top + WizardForm.WelcomeLabel2.Height - 4*TopInc;
  CreateButton(Left, Top, '&Check IIS', @IISButtonOnClick);
end;
