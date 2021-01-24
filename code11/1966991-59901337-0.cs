    corePolicy = _db.Policies
    .OrderByDescending(p => p.BatchId)
    .Include(policy => policy.PolicyRisks.Select(policyRisks =>
        policyRisks.TransactionMovements))
    .Include(policy => policy.PolicyRisks.Select(policyRisks =>
        policyRisks.PolicyRiskClaims.Select(prc =>
            prc.TransactionMovements)))
    .AsNoTracking()
	.Where(p => p.PolicyRisks.Any(pr => pr.PolicyRiskClaims.Any(prc => prc.TransactionMovements.Any(tm => tm.TransactionReference == 'ABC'))))
    .First(p =>
        p.PolicyReference == policyFromStaging.PolicyReference &&
        p.PolicySourceSystemId == policyFromStaging.PolicySourceSystemId);
		
