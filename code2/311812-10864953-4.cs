    DescribeImageAttributeRequest describeImageAttributeRequest = new DescribeImageAttributeRequest().WithImageId("ami-name").WithAttribute("blockDeviceMapping");
    
    DescribeImageAttributeResponse describeImageAttributeResponse = new DescribeImageAttributeResponse();
    
    describeImageAttributeResponse = ec2.DescribeImageAttribute(describeImageAttributeRequest);
