     private static void Main(string[] args)
            {
                var k8SClientConfig = new KubernetesClientConfiguration {  Host = "http://127.0.0.1:8080" };
                IKubernetes client = new Kubernetes(k8SClientConfig);
    
                ListDeployments(client);
    
                V1Deployment deployment = new V1Deployment()
                {
                    ApiVersion = "apps/v1",
                    Kind = "Deployment",
                    Metadata = new V1ObjectMeta()
                    {
                        Name = "nepomucen",
                        NamespaceProperty = null,
                        Labels = new Dictionary<string, string>()
                    {
                        { "app", "nepomucen" }
                    }
                    },
                    Spec = new V1DeploymentSpec
                    {
                        Replicas = 1,
                        Selector = new V1LabelSelector()
                        {
                            MatchLabels = new Dictionary<string, string>
                        {
                            { "app", "nepomucen" }
                        }
                        },
                        Template = new V1PodTemplateSpec()
                        {
                            Metadata = new V1ObjectMeta()
                            {
                                CreationTimestamp = null,
                                Labels = new Dictionary<string, string>
                            {
                                 { "app", "nepomucen" }
                            }
                            },
                            Spec = new V1PodSpec
                            {
                                Containers = new List<V1Container>()
                            {
                                new V1Container()
                                {
                                    Name = "nginx",
                                    Image = "nginx:1.7.9",
                                    ImagePullPolicy = "Always",
                                    Ports = new List<V1ContainerPort> { new V1ContainerPort(80) }
                                }
                            }
                            }
                        }
                    },
                    Status = new V1DeploymentStatus()
                    {
                        Replicas = 1
                    }
                };
