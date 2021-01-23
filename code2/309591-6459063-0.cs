          dr = viewCmd.ExecuteReader();
          if( dr.Read())
          {
            Submission tempSubmission = new Submission();
            tempSubmission.SubmissionId1 = dr.GetInt32(0);
            tempSubmission.CustomerId1 = dr.GetInt32(1);
            tempSubmission.BrokerId1 = dr.GetInt32(2);
            tempSubmission.Coverage1 = dr.GetInt32(3);
            tempSubmission.CurrentCoverage1 = dr.GetInt32(4);
            tempSubmission.PrimEx1 = dr.GetInt32(5);
            tempSubmission.Retention1 = dr.GetInt32(6);
            tempSubmission.EffectiveDate1 = dr.GetDateTime(7);
            tempSubmission.Commission1 = dr.GetInt32(8);
            tempSubmission.Premium1 = dr.GetInt32(9);
            tempSubmission.Comment1 = dr.GetString(10);
            return tempSubmission;
          }
          return null;
