            List<DifferentTypes> smallStrings = new List<DifferentTypes>();
            List<DifferentTypes> mediomStrings = new List<DifferentTypes>();
            List<DifferentTypes> largeStrings = new List<DifferentTypes>();
            for (int i = 0; i < 10; i++)
            {
                string strSmallTest = "This is a small string test for different approachs provided here.";
                smallStrings.Add(Approachs(strSmallTest, "small"));
                string mediomSize = "Any public static (Shared in Visual Basic) members of this type are thread safe. Any instance members are not guaranteed to be thread safe."
                                    + "Windows 7, Windows Vista SP1 or later, Windows XP SP3, Windows Server 2008 (Server Core Role not supported), Windows Server 2008 R2 "
                                    + "(Server Core Role not supported), Windows Server 2003 SP2"
                                    + " .NET Framework does not support all versions of every platform. For a list of the supported versions, see .NET Framework System Requirements. ";
                mediomStrings.Add(Approachs(mediomSize, "Mediom"));
                string largeSize =
                    "This is a question that I get very frequently, and I always tried to dodged the bullet, but I get it so much that I feel that I have to provide an answer. Obviously, I am (not so) slightly biased toward NHibernate, so while you read it, please keep it in mind." +
                    "EF 4.0 has done a lot to handle the issues that were raised with the previous version of EF. Thinks like transparent lazy loading, POCO classes, code only, etc. EF 4.0 is a much nicer than EF 1.0." +
                    "The problem is that it is still a very young product, and the changes that were added only touched the surface. I already talked about some of my problems with the POCO model in EF, so I won’t repeat that, or my reservations with the Code Only model. But basically, the major problem that I have with those two is that there seems to be a wall between what experience of the community and what Microsoft is doing. Both of those features shows much of the same issues that we have run into with NHibernate and Fluent NHibernate. Issues that were addressed and resolved, but show up in the EF implementations." +
                    "Nevertheless, even ignoring my reservations about those, there are other indications that NHibernate’s maturity makes itself known. I run into that several times while I was writing the guidance for EF Prof, there are things that you simple can’t do with EF, that are a natural part of NHibernate." +
                    "I am not going to try to do a point by point list of the differences, but it is interesting to look where we do find major differences between the capabilities of NHibernate and EF 4.0. Most of the time, it is in the ability to fine tune what the framework is actually doing. Usually, this is there to allow you to gain better performance from the system without sacrificing the benefits of using an OR/M in the first place.";
                largeStrings.Add(Approachs(largeSize, "Large"));
                Console.WriteLine();
            }
            Console.WriteLine("/////////////////////////");
            Console.WriteLine("average small for saeed: {0}", smallStrings.Average(x => x.saeed));
            Console.WriteLine("average small for Jay: {0}", smallStrings.Average(x => x.Jay));
            Console.WriteLine("average small for Simmon: {0}", smallStrings.Average(x => x.Simmon));
            Console.WriteLine("/////////////////////////");
            Console.WriteLine("average mediom for saeed: {0}", mediomStrings.Average(x => x.saeed));
            Console.WriteLine("average mediom for Jay: {0}", mediomStrings.Average(x => x.Jay));
            Console.WriteLine("average mediom for Simmon: {0}", mediomStrings.Average(x => x.Simmon));
            Console.WriteLine("/////////////////////////");
            Console.WriteLine("average large for saeed: {0}", largeStrings.Average(x => x.saeed));
            Console.WriteLine("average large for Jay: {0}", largeStrings.Average(x => x.Jay));
            Console.WriteLine("average large for Simmon: {0}", largeStrings.Average(x => x.Simmon));
