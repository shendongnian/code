    [Then(@"I choose (.*) in dropdown MainApplicantMaritalStatus and Check value")]
    public void IChooseInDropdownMainApplicantMaritalStatusAndCheckValue(string status)
    {
        // lets say you have select element
        WebElement maritalStatus = driver.findElement();
        WebElement option = maritalStatus.findElement(By.xpath("./option[normalize-space(.)='" + status + "']"));
        // click on option   
        option.click();
    }
