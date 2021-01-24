    protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
    {
        base.OnActivityResult(requestCode, resultCode, data);
            if (resultCode == Result.Canceled)
            {
                Finish();
            }
            else
            {
                try
                {
                var _uri = data.Data;
                var filePath = IOUtil.getPath(this, _uri);
                if (string.IsNullOrEmpty(filePath))
                    filePath = _uri.Path;
                var file = IOUtil.readFile(filePath);// here we can get byte array
            }
                catch (Exception readEx)
                {
                    System.Diagnostics.Debug.Write(readEx);
                }
                finally
                {
                    Finish();
                }
        }
    }
