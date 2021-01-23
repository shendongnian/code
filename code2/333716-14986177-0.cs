    BindingList<Application> applications = new BindingList<Application>();
    dgvApplications.DataSource = applications;
    // set AutoGenerateColumns to false and manually add columns to get pretty column names.
    // set AutoGenerateColumns to true to not worry about adding columns in early prototyping
    dgvModules.AutoGenerateColumns = true;  
