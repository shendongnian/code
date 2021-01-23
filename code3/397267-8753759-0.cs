	Select Customer.CustomerId,
	Customer.FirstName,
	Customer.LastName,
	Customer.email,
	Customer.Phone,
	Count(ClickId) [Total Clicks]
	From Customer
	Join LoginInformation
	ON customer.CustomerId = LoginInformation.CustomerId
	JOIN ProductLinks
	ON LoginInformation.LoginId= ProductLinks.LoginId
	JOIN Click
	ON Click.LoginId = LoginInformation.LoginId
	GROUP BY Customer.CustomerId,
	Customer.FirstName,
	Customer.LastName,
	Customer.email,
	Customer.Phone
