        //add the BOM
        byte[] bBOM = new byte[] { 0xEF, 0xBB, 0xBF };
        byte[] bContent = ms.ToArray();
        byte[] bToWrite = new byte[bBOM.Length + bContent.Length];
 
        //combile the BOM and the content
        bBOM.CopyTo( bToWrite, 0 );
        bContent.CopyTo( bToWrite, bBOM.Length );
 
        //write to the client
        HttpContext.Current.Response.Write( Encoding.UTF8.GetString( bToWrite ) );
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.End();
