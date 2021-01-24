public class MainActivity : FormsAppCompatActivity
    {
        ...
		
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
			try
			{
				base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
				((PermissionsService)PermissionsService.Instance).OnRequestPermissionResult(requestCode, permissions, grantResults);
			}
			catch(UnauthorizedAccessException)
			{
				HandleExceptionAndContinue()
			}
        }
    }
