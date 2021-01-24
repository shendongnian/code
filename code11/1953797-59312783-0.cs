            public class TestedService
        {
            readonly IDependency m_dependency;
            readonly ISomethingDoer m_somethingDoer;
            public TestedService(
                IDependency dependency,
                ISomethingDoer somethingDoer)
            {
                m_dependency = dependency;
                m_somethingDoer = somethingDoer;
            }
        
            public async Task Start()
            {
                m_dependency.SomethingHappened += m_somethingDoer.OnSomethingHanppened;
                await m_dependency.Start();
            }
        }
        
        interface ISomethingDoer
        {
           Task OnSomethingHanppened(object sender, SoAndSoEventArgs args);
        }
        class SomethingDoer : ISomethingDoer
        {
            readonly ISecondDependency m_secondDependency;
            readonly ISoAndSoMapper m_soAndSoMapper;
            public SomethingDoer(ISecondDependency secondDependency, ISoAndSoMapper soAndSoMapper)
            {
               m_secondDependency = secondDependency;
    m_soAndSoMapper = soAndSoMapper;
            }
    
            public async Task OnSomethingHanppened(object sender, SoAndSoEventArgs args)
            {
                SoAndSo soAndSo = m_soAndSoMapper.MapToDTO(args);
                await m_secondDependency.DoYourJob(soAndSo),
            }
        }
