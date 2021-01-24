    public class RoadListToRoadListDtoMapper : IMapToNew<List<Road>, List<RoadDto>>
    {
        private RoadToRoadDtoMapper roadToRoadDtoMapper = new RoadToRoadDtoMapper();
        public List<RoadDto> Map(List<Road> models)
        {
            var roadDtos = new List<RoadDto>();
            foreach(var road in models){
                roadDtos.Add(roadToRoadDtoMapper.Map(road));
            }
            return roadDtos;  
        }
    }
