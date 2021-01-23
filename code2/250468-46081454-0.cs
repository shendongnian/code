    using Grappachu.Movideo.Core.Helpers.TitleCleaner;
    using SharpTestsEx;
    using Xunit;
    
    namespace Grappachu.MoVideo.Test
    {
        public class TitleCleanerTest
        {
            [Theory]
            [InlineData("Avengers.Confidential.La.Vedova.Nera.E.Punisher.2014.iTALiAN.Bluray.720p.x264 - BG.mkv",
                "Avengers Confidential La Vedova Nera E Punisher", 2014)]
            [InlineData("Fuck You, Prof! (2013) BDRip 720p HEVC ITA GER AC3 Multi Sub PirateMKV.mkv",
                "Fuck You, Prof!", 2013)]
            [InlineData("Il Libro della Giungla(2016)(BDrip1080p_H264_AC3 5.1 Ita Eng_Sub Ita Eng)by siste82.avi",
                "Il Libro della Giungla", 2016)]
            [InlineData("Il primo dei bugiardi (2009) [Mux by Little-Boy]", "Il primo dei bugiardi", 2009)]
            [InlineData("Il.Viaggio.Di.Arlo-The.Good.Dinosaur.2015.DTS.ITA.ENG.1080p.BluRay.x264-BLUWORLD",
                "il viaggio di arlo", 2015)]
            [InlineData("La Mafia Uccide Solo D'estate 2013 .avi",
                "La Mafia Uccide Solo D'estate", 2013)]
            [InlineData("Ip.Man.3.2015.iTA.AC3.5.1.448.Chi.Aac.BluRay.m1080p.x264.Sub.[scambiofile.info].mkv",
                "Ip Man 3", 2015)]
            [InlineData("Inferno.2016.BluRay.1080p.AC3.ITA.AC3.ENG.Subs.x264-WGZ.mkv",
                "Inferno", 2016)]
            [InlineData("Ghostbusters.2016.iTALiAN.BDRiP.EXTENDED.XviD-HDi.mp4",
                "Ghostbusters", 2016)]
            [InlineData("Transcendence.mkv", "Transcendence", null)]
            [InlineData("Being Human (Forsyth, 1994).mkv", "Being Human", 1994)]
            public void Clean_should_return_title_and_year_when_possible(string filename, string title, int? year)
            {
                var res = MovieTitleCleaner.Clean(filename);
    
                res.Title.ToLowerInvariant().Should().Be.EqualTo(title.ToLowerInvariant());
                res.Year.Should().Be.EqualTo(year);
            }
        }
    }
