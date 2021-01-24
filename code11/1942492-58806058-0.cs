    this.dataFactoryMock
        .Setup(factory => factory.Factory(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
        .Returns((DateTime adjustedAnalysisDate, DateTime analysisDate) => 
            commonDataFactory.Factory(adjustedAnalysisDate, analysisDate)
        );
