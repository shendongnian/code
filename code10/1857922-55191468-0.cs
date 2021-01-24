var coupondetails = new couponDetail[] {
    new couponDetail
    {
        description = "75% off the original price",
        value = 50
    },
    new couponDetail
    {
        description = "500 off the original price",
        value = 20
    }
};
var couponService = DependencyResolver.Resolve<Mock<ICouponWebServiceAdapter>>();
couponService
    .Setup(a => a.checkCouponAvailability(It.IsAny<orderLine[]>(), It.IsAny<orderHeader>()))
    .Returns(coupondetails);
2. You can pass a method to returns which MUST take all of the arguments passed into the original method. Example below:
var couponService = DependencyResolver.Resolve<Mock<ICouponWebServiceAdapter>>();
couponService
    .Setup(a => a.checkCouponAvailability(It.IsAny<orderLine[]>(), It.IsAny<orderHeader>()))
    .Returns((orderLine[] arg1, orderHeader arg2) => {
        return new couponDetail[] {
            new couponDetail
            {
                description = "75% off the original price",
                value = 50
            },
            new couponDetail
            {
                description = "500 off the original price",
                value = 20
            }
        };
    });
