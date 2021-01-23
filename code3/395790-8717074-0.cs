        public override string ToString()
        {
            string foo =
                string.Format( "var_job = {1}{0}var_jobType = {2}{0}var_jobname = {3}{0}var_content = {4}{0}var_contenticon = {5}{0}",
                    Environment.NewLine,
                    this.var_jobname,
                    this.jobType,
                    this.var_jobname,
                    this.var_content,
                    this.var_contenticon );
                
            return foo;
        }
