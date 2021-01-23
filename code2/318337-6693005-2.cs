    Expect.Call(ServiceClient.GetMock<IUserService>().GetCommunityLightPagered(null, 1, null,null, new PagingInfo
                    {
                        Page = 1,
                        Rows = 10,
                        SortColumn = "Id",
                        SortOrder = "desc"
                    })
                    ).IgnoreArguments().Return(TestHelper.CommunityInfoLightDTO());
