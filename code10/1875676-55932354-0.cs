    public void RemoveIBar(IBar ibar) {
        if (ibar is Bar) {
            Bars.Remove((Bar)ibar);
        } else {
            throw new NotImplementedException();
        }
    }
