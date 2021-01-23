        public StemmingProcessorResults ProcessText(string text)
        {
                return new StemmingProcessorResults(
                        new []{
                            new StemmingProcessorResultItem("following", 1),
                            new StemmingProcessorResultItem("flow", 2),
                            new StemmingProcessorResultItem("classification", 1),
                            new StemmingProcessorResultItem("class", 1),
                            new StemmingProcessorResultItem("flower", 3),
                            new StemmingProcessorResultItem("friend", 4),
                            new StemmingProcessorResultItem("friendly", 4),
                            new StemmingProcessorResultItem("classes", 1)
                        }
                    );
        }
