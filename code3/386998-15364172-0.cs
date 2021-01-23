    List<ListTwoColumns> JobIDAndJobName = new List<ListTwoColumns>();
        for (int index = 0; index < JobIDAndJobName.Count;index++)
                {
                    ListTwoColumns List = JobIDAndJobName[index];
                    if (List.Text == this.cbJob.Text)
                    {
                        JobID = List.ID;
                    }
                }
