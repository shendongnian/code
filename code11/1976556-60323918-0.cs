var result = new EcheqSubmissionInfoApi
            {
                Id = submission.Id,
                DefinitionId = submission.DefinitionId,
                SubmittedOnUtc = submission.SubmittedOnUtc,
                AssignedByOrgId = submission.AssignedByOrgId,
                AssignedByProfId = submission.AssignedByProfId,
                AssignedOnUtc = submission.AssignedOnUtc,
                AssignedToId = submission.AssignedToId,
                ValidUntilUtc = submission.ValidUntilUtc,
                CurrentPage = submission.CurrentPage,
                Progress = submission.Progress
            };
result.Status = submission.Status.StatusDbToApi();
3) Rewrite `StatusDbToApi` into a non-static method on `EcheqSubmissionStatus` that returns the correct status.
