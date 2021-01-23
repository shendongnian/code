    string[] validFileTypes = { "bmp", "jpg", "png" };
        string ext = Path.GetExtension(fileUpload1.FileName);
        bool isValidType = false;
        for (int i = 0; i < validFileTypes.Length; i++)
        {
            if (ext == "." + validFileTypes[i])
            {
                isValidType = true;
                break;
            }
        }
        if (!isValidType)
        {
            lblMessage.Text = "Invalid File Type";
        }
        else
        {
            lblMessage.Text = "File Uploaded Successfullty";
        }
