    Progress<double> progress = new Progress<double>(x => {
	// When progress in unknown, -1 will be sent
	if (x < 0){
		progressBar.IsIndeterminate = true;
	}else{
		progressBar.IsIndeterminate = false;
		progressBar.Value = x;
	}
    });
