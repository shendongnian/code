	void Main()
	{
		var CalibracionVerificacion = new List<Equipo>();
	
		var results = CalibracionVerificacion		
			.Join(
				CalibracionVerificacion.Where(x => !String.IsNullOrWhiteSpace(x.magnitudId)), 
				c1 => c1.equipoId, 
				c2 => c2.equipoId, 
				(c1, c2) => new {c1, c2})
			.GroupBy(x => x.c2.magnitudId)
			.Select(g => new
			{
				MagnitudID = g.Key,
				CalibracionID = g.Select(x => x.c1.calibracionVerificacionId),
				MaxDate = g.Max(x => x.c1.fechaPrevista)
			})
			.Min(g => g.MaxDate);	
			
	}
	
	class Equipo {
		public int equipoId  { get; set; }
		public string magnitudId  { get; set; }
		public int calibracionVerificacionId { get; set; }
		public int fechaPrevista  { get; set; }
	}
