            AmazonEC2 ec2 = AWSClientFactory.CreateAmazonEC2Client();
       
            DeregisterImageRequest deregisterImageRequest = new DeregisterImageRequest();
            deregisterImageRequest.ImageId = AMIName;
            DeregisterImageResponse deregisterImageResponse = new DeregisterImageResponse();
            deregisterImageResponse = ec2.DeregisterImage(deregisterImageRequest);
