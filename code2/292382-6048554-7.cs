    CREATE PROCEDURE [dbo].[GetStuffByStatus]
    @status varchar(255) = null
    AS 
    BEGIN
	IF @status IS NOT NULL
	BEGIN
	
		SELECT Customer.SubId, Customer.CustName, Customer.CustCity, Customer.CustState, Broker.BroName, Broker.BroState, 
		Broker.EntityType, Submission.Coverage, Status.Status 
		FROM Submission 
		WHERE Status = @status
		INNER JOIN Broker ON Broker.SubId = Submission.SubmissionId 
		INNER JOIN Customer ON Customer.SubId = Submission.SubmissionId INNER JOIN Status ON Status.StatusId = Submission.StatusId
	
	END
	ELSE
		SELECT Customer.SubId, Customer.CustName, Customer.CustCity, Customer.CustState, Broker.BroName, Broker.BroState, Broker.EntityType, Submission.Coverage, Status.Status 
		
		FROM Submission 
		
		INNER JOIN Broker ON Broker.SubId = Submission.SubmissionId 
		INNER JOIN Customer ON Customer.SubId = Submission.SubmissionId INNER JOIN Status ON Status.StatusId = Submission.StatusId
    END
