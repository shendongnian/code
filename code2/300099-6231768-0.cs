    catch (Exception)
    {
        MessageBox.Show(
             Conversion.ErrorToString(),  // Caption
             "Error:",                    // Title displayed
             MessageBoxButtons.OK,        // Only show OK button
             MessageBoxIcon.Error);       // Show error icon (similar to Critical)
    }
