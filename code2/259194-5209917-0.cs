    protected virtual void fileSortProgressMerging(FileSort o, double progress) {
        Gtk.Application.Invoke (delegate {
            progressBar.Fraction = progress;
            progressBar.Text = "Merging...";
        });    
    }
